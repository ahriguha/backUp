#include <fstream>
#include <iostream>
using namespace std;

int main()
{
	ofstream file;
	file.open("MAKS_LOH.txt");
	file << "MAKS LOH MAKS LOH MAKS LOH MAKS LOH MAKS LOH MAKS LOH MAKS LOH MAKS LOH MAKS LOH MAKS LOH ";
	file.close();
	for (int i = 0; i < 2; i++) {
		system("copy C:MAKS_LOH.txt C:MAKS_LOH.txt"+i);
	}
	return 0;
}
