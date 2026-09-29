#include <iostream>
#include "wjUtility.h" // PrintHWNumber, LineJump
using namespace std;

void HW1()
{
	PrintHWNumber(1);
	int input = 0;
	cin >> input;
	if (input < -10 || 10 < input)
		return;

	while (input >= -15)
	{
		input -= 5;
		cout << "input : " << input << "\n";
	}
	LineJump();
}

void HW2()
{
	PrintHWNumber(2);
	int a, b;
	cin >> a >> b;

	int i = a;
	int count = 0, sum = 0;
	do
	{
		if (i % 3 == 0)
		{
			if (i >= a + 3) // 첫 출력이 아니면
			{
				cout << ", ";
			}
			cout << i;
			sum += i;
			count++;
		}
		i++;
	} while (i <= b);

	cout << "\n총 갯수 : " << count << " / 합 출력 : " << sum << "\n";
	LineJump();
}

void HW3()
{
	PrintHWNumber(3);
	int n = 0;
	cin >> n;
	if (n < 2 || 9 < n)
		return;

	int sum = 0;
	for (int i = 1; i < 10; i++)
	{
		cout << n << " * " << i << " = " << n * i << "\n";
		sum += n * i;
	}
	cout << sum << "\n";
	LineJump();
}

int main()
{
	HW1();
	HW2();
	HW3();
}