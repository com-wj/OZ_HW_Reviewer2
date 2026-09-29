#include <iostream>
#include "wjUtility.h" // PrintHWNumber, LineJump
using namespace std;

void HW1()
{
	PrintHWNumber(1);
	int a, b;
	cin >> a >> b;

	cout << "a + b = " << a + b << "\n";
	cout << "a - b = " << a - b << "\n";
	cout << "a * b = " << a * b << "\n";
	cout << "a / b = " << a / b << "\n";
	cout << "\n";

	int c;
	cin >> a >> b >> c;
	cout << "(a + b) * (c + a) % a = " << (a + b) * (c + a) % a << "\n";
	cout << "(c % b) + (a * 2) = " << (c % b) + (a * 2) << "\n";
	cout << "(a + b + c) % (c + 1) = " << (a + b + c) % (c + 1) << "\n";
	LineJump();
}

void HW2()
{
	PrintHWNumber(2);
	int a, b;
	cin >> a >> b;
	cout << "몫 : " << a / b << " / 나머지 : " << a % b << "\n";
	LineJump();
}

void HW3()
{
	PrintHWNumber(3);
	int a, b, q, r;
	cin >> a >> b;
	q = a / b;
	r = a % b;
	cout << "몫 : " << q << " / 나머지 : " << r << "\n";
	cout << "원래 숫자(a) : " << b * q + r << "\n";
	LineJump();
}

void ChallengeHW1()
{
	//for (int i = 0; i < 9; i++)
	//{
		//cout << (i <= 4) ? (1 + 2 * i) : (9 - 2 * i) << endl;
	//}
}
// 1 3 5 7 9 7 5 3 1

int main()
{
	HW1();
	HW2();
	HW3();
	ChallengeHW1();
}