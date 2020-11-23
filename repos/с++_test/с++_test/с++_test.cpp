#define _CRT_SECURE_NO_WARNINGS
#include <assert.h>
#include <stdio.h>
#include <fstream>
#include <vector>
#include <cstdlib>
#include <conio.h>
#include <iostream>

using namespace std;

struct Node {
	Node* left;
	Node* right;
	int value;

	Node(int key) : value(key), left(NULL), right(NULL) {}
};

struct Node_print {
	Node_print* child;
	bool printing_last_child;
};

Node_print* root = NULL;

static void insert(Node*& node, int key) {
	if (node == nullptr) {
		node = new Node(key);
	}
	else {
		if (key < node->value) {
			insert(node->left, key);
		}
		else if (key > node->value) {
			insert(node->right, key);
		}
	}
}

void print_subtree(const Node* tree) {

	Node_print* parent;
	if (root != NULL) {
		printf(" ");
		Node_print* s = root;
		while (s->child != NULL) {
			printf(s->printing_last_child ? " " : "| ");
			s = s->child;
		}
		parent = s;
		printf(parent->printing_last_child ? "-" : "+");
	}
	else {
		parent = NULL;
	}
	printf(">%i\n", tree->value);
	if ((tree->right != NULL) || (tree->left != NULL)) {
		Node_print s;
		if (parent != NULL) {
			parent->child = &s;
		}
		else {
			root = &s;

		}
		s.child = NULL;
		if (tree->right != NULL) {
			s.printing_last_child = (tree->left == NULL);
			print_subtree(tree->right);
		}
		if (tree->left != NULL) {
			s.printing_last_child = true;
			print_subtree(tree->left);
		}
		if (parent != NULL) {
			parent->child = NULL;
		}
		else {
			root = NULL;
		}
	}
}

void print_tree(const Node* root_tree) {
	assert(root == NULL);
	try {
		if (root_tree != NULL) {
			print_subtree(root_tree);
		}
	}
	catch (...) {
		root = NULL;
		throw;
	}
}

Node* DeleteNode(Node* node, int val) {
	if (node == NULL)
		return node;

	if (val == node->value) {

		Node* tmp;
		if (node->left == NULL)
			tmp = node->right;
		else {

			Node* ptr = node->left;
			if (ptr->right == NULL) {
				ptr->right = node->right;
				tmp = ptr;
			}
			else {

				Node* pmin = ptr->right;
				while (pmin->right != NULL) {
					ptr = pmin;
					pmin = ptr->right;
				}
				ptr->right = pmin->left;
				pmin->right = node->right;
				pmin->left = node->left;
				tmp = pmin;
			}
		}

		delete node;
		return tmp;
	}
	else if (val < node->value)
		node->left = DeleteNode(node->left, val);
	else
		node->right = DeleteNode(node->right, val);
	return node;
}

Node* GetData(FILE* file)
{
	file = fopen("Nodes.bin", "r+b");
	Node* tree = NULL;

	if (file == NULL)
	{
		cout << "ERROR!\n";
		return NULL;
	}
	fseek(file, 0, SEEK_END);
	int count = ftell(file) / sizeof(int);
	int* nodes = new int[count];
	fseek(file, 0, SEEK_SET);
	fread(nodes, sizeof(int), count, file);

	for (int i = 0; i < count; i++)
	{
		insert(tree, nodes[i]);
	}

	print_tree(tree);
	fclose(file);
	return tree;
}

void Task1()
{
	FILE* fin = fopen("Nodes.bin", "r+b");
	Node* tree = NULL;

	if (fin == NULL)
	{
		cout << "ERROR!\n";
		return;
	}

	fseek(fin, 0, SEEK_END);
	int count = ftell(fin) / sizeof(int);
	int* nodes = new int[count];
	fseek(fin, 0, SEEK_SET);
	fread(nodes, sizeof(int), count, fin);
	fclose(fin);

	for (int i = 0; i < count; i++)
	{
		insert(tree, nodes[i]);
	}

	FILE* fout;
	fout = fopen("Nodes.bin", "w+b");
	if (fout == NULL)
	{
		cout << "ERROR\n";
		return;
	}
	fwrite(nodes, sizeof(int), count, fout);
	int node_name;
	while (true)
	{
		cout << "Enter a number of node(ESc to exit): ";

		if (_getch() == 27) break;

		cin >> node_name;
		insert(tree, node_name);
		fseek(fout, 0, SEEK_END);
		fwrite((char*)&node_name, sizeof(int), 1, fout);
	}
	fclose(fout);

}

void Task2()
{
	FILE* fin;
	fin = fopen("Nodes.bin", "r+b");
	Node* tree = NULL;

	if (fin == NULL)
	{
		cout << "ERROR!\n";
		return;
	}
	fseek(fin, 0, SEEK_END);
	int count = ftell(fin) / sizeof(int);
	int* nodes = new int[count];
	if (fin == NULL)
	{
		cout << "ERROR\n";
		return;
	}
	fseek(fin, 0, SEEK_SET);
	fread(nodes, sizeof(int), count, fin);

	for (int i = 0; i < count; i++)
	{
		insert(tree, nodes[i]);
	}
	print_tree(tree);
	fclose(fin);
	fin = fopen("Nodes.bin", "w+b");
	fseek(fin, 0, SEEK_SET);

	cout << "\n Enter the node to delete:";
	int node_del;
	cin >> node_del;
	tree = DeleteNode(tree, node_del);
	print_tree(tree);

	for (int i = 0; i < count; i++)
	{
		if (nodes[i] != node_del)
		{
			fwrite((char*)&nodes[i], sizeof(int), 1, fin);
		}
	}

	fclose(fin);
}

void DFS_Level(Node* node, int& sum, int sum_level)
{
	static int level = 1;
	if (level == sum_level)
		sum += node->value;
	if (node->left != NULL)
	{
		level++;
		DFS_Level(node->left, sum, sum_level);
	}
	if (node->right != NULL)
	{
		level++;
		DFS_Level(node->right, sum, sum_level);
	}
	level--;
}

int BFS_Level(Node* node, int sum_level) {
	vector<Node>queue;
	vector<int>level_of_queue;
	int sum = 0;
	queue.push_back(*node);
	level_of_queue.push_back(1);
	while (queue.size() > 0) {
		Node tempNode = queue[0];
		int templevel = level_of_queue[0];
		queue.erase(queue.begin());
		level_of_queue.erase(level_of_queue.begin());
		if (templevel == sum_level)
			sum += tempNode.value;
		if (tempNode.left) {
			queue.push_back(*tempNode.left);
			level_of_queue.push_back(templevel + 1);
		}
		if (tempNode.right) {
			queue.push_back(*tempNode.right);
			level_of_queue.push_back(templevel + 1);
		}
	}
	return sum;
}

void DFS(Node* node, int& sum)
{
	sum += node->value;
	if (node->left != NULL)
		DFS(node->left, sum);
	if (node->right != NULL)
		DFS(node->right, sum);
}

void DFS_Min(Node* node, int& min)
{

	if (node->left != NULL)
	{
		if (min > node->left->value)
			min = node->left->value;
		DFS_Min(node->left, min);
	}

	if (node->right != NULL)
	{
		DFS_Min(node->right, min);
	}

}

void DFS_Max(Node* node, int& min)
{

	if (node->left != NULL)
	{
		DFS_Max(node->left, min);
	}

	if (node->right != NULL)
	{
		if (min < node->right->value)
			min = node->right->value;
		DFS_Max(node->right, min);
	}

}

int BFS(Node* node) {
	vector<Node>queue;
	int sum = 0;
	queue.push_back(*node);
	while (queue.size() > 0) {
		Node tempNode = queue[queue.size() - 1];
		queue.pop_back();
		sum += tempNode.value;
		if (tempNode.left) {
			queue.push_back(*tempNode.left);
		}

		if (tempNode.right) {
			queue.push_back(*tempNode.right);
		}
	}
	return sum;
}

int BFS_Min(Node* node)
{
	vector<Node>queue;
	int min;
	queue.push_back(*node);
	min = node->value;
	while (queue.size() > 0) {
		Node tempNode = queue[queue.size() - 1];
		queue.pop_back();
		if (tempNode.value < min)
			min = tempNode.value;
		if (tempNode.left) {
			queue.push_back(*tempNode.left);
		}

		if (tempNode.right) {
			queue.push_back(*tempNode.right);
		}
	}
	return min;
}

int BFS_Max(Node* node)
{
	vector<Node>queue;
	int max;
	queue.push_back(*node);
	max = node->value;
	while (queue.size() > 0) {
		Node tempNode = queue[queue.size() - 1];
		queue.pop_back();
		if (tempNode.value > max)
			max = tempNode.value;
		if (tempNode.left) {
			queue.push_back(*tempNode.left);
		}

		if (tempNode.right) {
			queue.push_back(*tempNode.right);
		}
	}
	return max;
}

void Task3(bool key)
{
	FILE* fout = NULL;
	Node* tree = GetData(fout);
	int sum = 0;
	if (key)
	{
		DFS(tree, sum);
	}
	else sum = BFS(tree);

	cout << "Sum of elements of tree:\t" << sum << endl;
	return;
}

void Task4(bool key)
{
	FILE* fout = NULL;
	Node* tree = GetData(fout);

	int level, sum = 0;
	cout << "Enter the level:\t";
	cin >> level;
	if (key)
	{
		sum = BFS_Level(tree, level);
	}
	else
	{
		DFS_Level(tree, sum, level);
	}

	cout << "Sum of elements on level " << level << " = " << sum << endl;
}

void Print_tree_from_file()
{
	FILE* fout = NULL;
	Node* tree = GetData(fout);
}

void Task5()
{
	int key1;
	cout << "\nChoose method:\n -1 BFS;\n -2 DFS.\n";
	key1 = _getch();
	cout << "Choose which element seek:\n -1 Minimal;\n -2 Maximal.\n";
	int key2 = _getch();


	switch (key1)
	{
	case 49:
	{

		switch (key2)
		{
		case 49:
		{
			FILE* fout = NULL;
			Node* tree = GetData(fout);

			cout << "Minimal element = " << BFS_Min(tree) << endl;
		}break;

		case 50:
		{
			FILE* fout = NULL;
			Node* tree = GetData(fout);
			cout << "Maximal element = " << BFS_Max(tree) << endl;
		}break;

		default: break;
		}
	}break;
	case 50:
	{
		switch (key2)
		{
		case 49:
		{
			FILE* fout = NULL;
			Node* tree = GetData(fout);
			int min = tree->value;
			DFS_Min(tree, min);
			cout << "Minimal element = " << min << endl;
		}break;

		case 50:
		{
			FILE* fout = NULL;
			Node* tree = GetData(fout);
			int max = tree->value;
			DFS_Max(tree, max);
			cout << "Maximal element = " << max << endl;
		}break;

		default: break;
		}
	}break;
	default: break;
	}
}

int main()
{
	cout << "Choose the option \n -1 Add Element;\n -2 Delete Element;\n -3 Find sum of Elements;\n -4 Find sum of elements on level;\n -5 Find min or max element;\n -6 Print tree.\n";
	int key = _getch();

	switch (key)
	{
	case 49: Task1(); break;

	case 50: Task2(); break;

	case 51: {
		int key1;
		cout << "\nChoose method:\n -1 BFS;\n -2 DFS.\n";
		key1 = _getch();;
		switch (key1)
		{
		case 49: Task3(false); break;
		case 50: Task3(true); break;
		default: break;
		}break;
	}
	case 52: {
		int key1;
		cout << "\nChoose method:\n -1 BFS;\n -2 DFS.\n";
		key1 = _getch();;
		switch (key1)
		{
		case 49: Task4(true); break;
		case 50: Task4(false); break;
		default: break;
		}
	}break;
	case 53: {
		Task5();
	}break;

	case 54: {
		Print_tree_from_file();
	}break;

	default: break;
	}

	return 0;
}
