#pragma once
#include <iostream>
#include <vector>
#include <windows.h>

template<class T> using Matrix = std::vector<std::vector<T>>;
class DoubleMatrix
{
public:
	DoubleMatrix(std::istream& input, int threadCount);
	void Print(std::ostream& ouput);
	int GetRank();
private:
	Matrix<double> _matrix;
	size_t _size;
	int _threadCount;
};

