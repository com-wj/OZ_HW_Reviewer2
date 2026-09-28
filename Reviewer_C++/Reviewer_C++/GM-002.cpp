#include <iostream>
#include <vector>
#include <string>
using namespace std;

void HW1()
{
	cout << "------ 과제 1 -----\n";

	vector<string> itemType = { "무기", "무기", "방어구", "방어구", "악세서리", "악세서리" };
	vector<int> damage = { 1, 3, 5, 7, 9, 10 };
	vector<int> price = { 5, 10, 15, 20, 25, 30 };
	vector<string> feature  = { "", "2회 공격 가능", "", "", "", "이동속도 증가" };

	cout << "아이템 종류 / 가격 / 데미지 / 특성\n";
	for (int i = 0; i < itemType.size(); i++)
	{
		cout << itemType[i] << " / " << damage[i] << " / " << price[i] << " / " << feature[i] << "\n";
	}
	cout << "\n";
}

void HW2()
{
	cout << "------ 과제 2 -----\n";
	srand(time(NULL));

	int a = rand() % 5 + 1;
	int b = rand() % 15 + 6;
	int c = rand() % 50 + 151;
	cout << "a : " << a << ", b : " << b << ", c : " << c << "\n";
	cout << "\n";
}

void HW3()
{
	cout << "------ 과제 3 -----\n";
	srand(time(NULL));

	int gold = 0;
	do
	{
		cout << "소지금을 입력해 주세요.(100 ~ 200) : ";
		cin >> gold;
	} while (100 > gold || gold > 200);

	int prize = rand() % 51 + 50;
	cout << "현상금 : " << prize << "골드\n";

	int tax = (gold + prize) * 0.1;

	cout << "세금" << tax << "골드를 징수하고, " << prize - tax << "골드를 획득했습니다.\n";
	cout << "\n";
}

void HW4()
{
	cout << "------ 과제 4 -----\n";
	int str = rand() % 10 + 1;
	int dex = rand() % 10 + 1;
	int Int = rand() % 10 + 1;
	int totalStats = str + dex + Int;

	cout << "str : " << str << ", dex : " << dex << ", int : " << Int << ", total : " << totalStats << "\n";
	cout << "\n";
}

int main()
{
	HW1();
	HW2();
	HW3();
	HW4();
}