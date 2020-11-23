#include "stdlib.h"
#include <iostream>
#include "fstream"
#include <string>
#include "ctime"
#include <cctype>

using namespace std;
void sort_bubble_15var(string* arr);
void sort_bubble_10var(string* arr);
void print(string* arr);
bool digit(char a);


int main()
{
	ifstream text;
	text.open("text.txt");
	if (!text)
	{
		cout << "file didn't open\n\n";
	}
	else
	{
		cout << "file is open\n\n";
	}
	string array[100];
	int i = 0;
	while (i < 100) 
	{
		getline(text, array[i]);
		i++;
	}
	text.close();//^array initializyng;

	sort_bubble_10var(array);

	print(array);
	system("pause");
	return 0;
}

void print(string* arr)
{
for (int i = 0; i < 100; i++)
	{
		cout << arr[i] << endl;
	}
}

void sort_bubble_15var(string* arr) {
	unsigned int start_time = clock();
	for (int j = 99; j >= 0; j--)
	{
		for (int i = 0; i< j; i++)
		{

			if (arr[i].length() > arr[i + 1].length())
			{
				swap(arr[i], arr[i + 1]);
			}
		}
	}
	unsigned int end_time = clock();
	unsigned int search_time = end_time - start_time;
	cout << "\n\n\n";
	cout << "sorting time is " << search_time << endl;
	ofstream textout;
	textout.open("textout_bubble_15.txt");
	for (int i = 0; i < 100; i++)
	{
		textout << arr[i]<<"\n";
	}
	textout.close();
}

void sort_bubble_10var(string* arr)
{
	unsigned int start_time = clock();
	for (int j = 99; j >= 0; j--)
	{
		for (int i = 0; i < j; i++)
		{
			int numbers1 = 0;
			for (int g = 0; g < arr[i].length(); g++)
			{
				if (digit(arr[i][g]))	
				{
					numbers1++;
				}
			}
			int numbers2 = 0;
			for (int g = 0; g < arr[i+1].length(); g++)
			{
				if (digit(arr[i+1][g]))
				{
					numbers2++;
				}
			}
			if (numbers1 < numbers2)
			{ swap(arr[i], arr[i + 1]);}
		}
	}
	/*if (arr[i].length() > arr[i + 1].length())
				{
					
				}*/
	unsigned int end_time = clock();
	unsigned int search_time = end_time - start_time;
	cout << "\n\n\n";
	cout << "sorting time is " << search_time << endl;
	ofstream textout;
	textout.open("textout_bubble_10.txt");
	for (int i = 0; i < 100; i++)
	{
		textout << arr[i] << "\n";
	}
	textout.close();
}

bool digit(char a)
{
	if (a == '0' && a == '1' && a == '3' && a == '4' && a == '5' && a == '6' && a == '7' && a == '8' && a == '9')
		return true;
	else return false;
	
}