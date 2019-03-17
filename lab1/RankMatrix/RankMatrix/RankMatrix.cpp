#include "pch.h"
#include "DoubleMatrix.h"
#include <fstream>
#include <ctime>
#include <string>

using namespace std;
template<class T> using Matrix = vector<vector<T>>;

int main(int argc, char *argv[])
{
	// HANDLE process = GetCurrentProcess();
	// SetProcessAffinityMask(process, 0b1111);
	unsigned int startTime = clock();
	if (argc != 3)
	{
		cout << "type so: Program.exe <inFile> <threadCount>";
		return 1;
	}

	int threadCount;
	try
	{
		threadCount = stod(argv[2]);
	}
	catch (exception ex)
	{
		cout << "<threadCount> must be is number";
		return 1;
	}

	if (threadCount > 16)
	{
		cout << "<threadCount> must be less than 17";
		return 1;
	}

	ifstream inFile;
	inFile.open(argv[1]);
	if (!inFile) {
		cout << "Unable to open inFile";
		return 1;
	}

	DoubleMatrix matrix(inFile, threadCount);
	cout << matrix.GetRank() << '\n';
	unsigned int endTime = clock();
	cout << "Work time " << endTime - startTime << " ms(10^-3)";
	// matrix.Print(cout);
	return 0;
}
