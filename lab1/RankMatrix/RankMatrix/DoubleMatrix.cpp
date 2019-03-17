#include "pch.h"
#include "DoubleMatrix.h"
#include <iostream>
#include <vector>
#include <windows.h>

using namespace std;
template<class T> using Matrix = std::vector<std::vector<T>>;

struct MatrixDescription
{
	vector<vector<double>>* matrixP;
	size_t startPos, endPos, line, column;
};

struct MatrixInitDescription
{
	vector<vector<double>>* matrixP;
	size_t matrixSize;
	istream* input;
};


bool IsZero(double value)
{
	double E = 0.0001;
	return abs(value) < E;
}

DWORD WINAPI InitMatrix(CONST LPVOID lpMatrixInitDescription)
{
	auto matrixInitDescription = (MatrixInitDescription*)lpMatrixInitDescription;
	double number;
	vector<double> line;
	for (size_t i = 0; i < matrixInitDescription->matrixSize; i++)
	{
		line.clear();
		for (size_t j = 0; j < matrixInitDescription->matrixSize; j++)
		{
			(*(matrixInitDescription->input)) >> number;
			line.push_back(number);
		}

		(*(matrixInitDescription->matrixP)).push_back(line);
	}
}

DWORD WINAPI NullifyMatrixSector(CONST LPVOID lpMatrixDescription)
{
	auto matrixDescription = (MatrixDescription*)lpMatrixDescription;
	size_t j = matrixDescription->line;
	size_t i = matrixDescription->column;
	for (size_t t = matrixDescription->startPos; t < matrixDescription->endPos; ++t)
	{
		if (t != j && !IsZero((*(matrixDescription->matrixP))[t][i]))
		{
			for (size_t p = i + 1; p < (*(matrixDescription->matrixP)).size(); ++p)
			{
				(*(matrixDescription->matrixP))[t][p] -= (*(matrixDescription->matrixP))[j][p] * (*(matrixDescription->matrixP))[t][i];
			}
		}
	}

	ExitThread(0);
}


DoubleMatrix::DoubleMatrix(istream& input, int threadCount)
{
	input >> _size;
	_threadCount = threadCount > _size ? _size : threadCount;
	auto* matrixInitDescription = new MatrixInitDescription;
	matrixInitDescription->input = &input;
	matrixInitDescription->matrixP = &_matrix;
	matrixInitDescription->matrixSize = _size;
	auto lpMatrixInitDescription = (LPVOID)matrixInitDescription;
	HANDLE* handle = new HANDLE;
	*handle = CreateThread(NULL, 2048, &InitMatrix, lpMatrixInitDescription, 0, NULL);
	WaitForMultipleObjects(1, handle, true, INFINITE);
}

int DoubleMatrix::GetRank()
{
	Matrix<double> matrixCopy(_matrix);
	int result = _size;
	vector<bool> usedLines(_size);

	for (size_t i = 0; i < _size; i++)
	{
		size_t j;

		for (j = 0; j < _size; j++)
		{
			double number = matrixCopy[j][i];
			if (!usedLines[j] && !IsZero(number))
				break;
		}

		if (j == _size)
		{
			--result;
			continue;
		}

		usedLines[j] = true;
		for (size_t t = i + 1; t < _size; t++)
		{
			matrixCopy[j][t] /= matrixCopy[j][i];
		}


		int step = _size / _threadCount;
		int threadCounter = _threadCount;
		HANDLE* handles = new HANDLE[_threadCount];

		for (size_t t = 0; threadCounter != 0; t += step)
		{
			--threadCounter;
			auto* matrixDescription = new MatrixDescription;
			matrixDescription->matrixP = &matrixCopy;
			matrixDescription->column = i;
			matrixDescription->line = j;
			matrixDescription->startPos = t;

			if (threadCounter != 0)
			{
				matrixDescription->endPos = t + step;
			}
			else
			{
				matrixDescription->endPos = _size;
			}
			auto lpMatrixDescription = (LPVOID)matrixDescription;
			handles[threadCounter] = CreateThread(NULL, 2048, &NullifyMatrixSector, lpMatrixDescription, 0, NULL);
		}

		WaitForMultipleObjects(_threadCount, handles, true, INFINITE);
		/*for (size_t t = 0; t < _size; ++t)
		{
			if (t != j && !IsZero(matrixCopy[t][i]))
			{
				for (size_t p = i + 1; p < _size; ++p)
				{
					matrixCopy[t][p] -= matrixCopy[j][p] * matrixCopy[t][i];
				}
			}
		}*/
	}

	return result;
}



void DoubleMatrix::Print(std::ostream& ouput)
{
	for (size_t i = 0; i < _size; i++)
	{
		for (size_t j = 0; j < _size; j++)
		{
			double number = _matrix[i][j];
			ouput << number << '\t';
		}
		ouput << '\n';
	}
}