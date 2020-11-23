#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
int n;

void print(int* a);
int control();
void exch(int& a, int& b);
void sort_quick(int* arr, int& first, int& last);
void sort_merge(int* array, int x);
void merge(int* merged, int lenD, int L[], int lenL, int R[], int lenR);
void sort_selection(int* array, int x);
void sort_insertion(int* array, int x);
void sort_bubble(int* array);

int main()
{
	n = control();
	int* a = new int[n];
	for (int i = 0; i < n; i++)
	{
		a[i] = 1;
	}
	int first = 0;
	int last = n - 1;
	//print(a);
	unsigned int start_time = clock();
	sort_quick(a, first, last);
	unsigned int end_time = clock();
	unsigned int search_time = end_time - start_time;
	cout << "\nProgramm working time: " << search_time << " ms" << endl;

	//for (int i = 0; i < n / 2; i++) {
	//	swap(a[i], a[n - i - 1]);
	//}

	//start_time = clock();
	//sort_quick(a, first, last);
	//end_time = clock();
	//search_time = end_time - start_time;
	//cout << "\nProgramm working time: " << search_time << " ms" << endl;

	//print(a);
	system("pause");
	return 0;
}

void print(int* a)
{
	for (int i = 0; i < n; i++)
	{
		cout << a[i] << '\t';

	}
	cout << endl;
}

int control()
{
	while (true)
	{
		cout << "Input number: ";
		cin >> n;
		if (cin.get() == '\n' && n > 0) break;
		else
		{
			cout << "Expecting for integer number";
			cin.clear();
			cin.sync();

		}
	}
	return n;
}

void exch(int& a, int& b)
{
	int tmp = a;
	a = b;
	b = tmp;
}

void sort_quick(int* arr, int& first, int& last)
{
	int f = first;
	int l = last;
	int mid = arr[(f + l) / 2];
	do
	{
		while (arr[f] < mid) f++;
		while (arr[l] > mid) l--;
		if (f <= l)
		{
			exch(arr[f], arr[l]);
			f++;
			l--;
		}
	} while (f < l);
	if (first < l) sort_quick(arr, first, l);
	if (f < last) sort_quick(arr, f, last);
}


void sort_merge(int* array, int x)
{
	if (x > 1) {
		int middle = x / 2;
		int rem = x - middle;
		int* L = new int[middle];
		int* R = new int[rem];
		for (int i = 0; i < x; i++) {
			if (i < middle) {
				L[i] = array[i];
			}
			else {
				R[i - middle] = array[i];
			}
		}
		sort_merge(L, middle);
		sort_merge(R, rem);
		merge(array, x, L, middle, R, rem);
	}
}

void merge(int* merged, int lenD, int L[], int lenL, int R[], int lenR) {
	int i = 0;
	int j = 0;
	while (i < lenL || j < lenR) {
		if (i < lenL & j < lenR) {
			if (L[i] <= R[j]) {
				merged[i + j] = L[i];
				i++;
			}
			else {
				merged[i + j] = R[j];
				j++;
			}
		}
		else if (i < lenL) {
			merged[i + j] = L[i];
			i++;
		}
		else if (j < lenR) {
			merged[i + j] = R[j];
			j++;
		}
	}
}

void sort_selection(int* array, int x)
{
	int j = 0;
	for (int i = 0; i < x; i++) {
		j = i;
		for (int k = i; k < x; k++) {
			if (array[j] > array[k]) {
				j = k;
			}
		}
		swap(array[i], array[j]);
	}
}

void sort_insertion(int* array, int x)
{
	int key = 0;
	int i = 0;
	for (int j = 1; j < x; j++) {
		key = array[j];
		i = j - 1;
		while (i >= 0 && array[i] > key) {
			array[i + 1] = array[i];
			i = i - 1;
			array[i + 1] = key;
		}
	}
}

void sort_bubble(int* array)
{
	for (int j = n - 1; j >= 0; j--)
	{
		for (int i = 0; i < j; i++)
		{
			if (array[i] > array[i + 1])exch(array[i], array[i + 1]);
		}
	}
}

//sort_merge(a, n);
//sort_selection(a, n);
//sort_insertion(a, n);
//sort_bubble(a);
