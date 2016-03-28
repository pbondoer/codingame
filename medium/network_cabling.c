#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <limits.h>
#include <math.h>

int main()
{
	int N;
	scanf("%d", &N);

	long avgY;
	int minX;
	int maxX;
	int pY[N];

	avgY = 0L;
	minX = INT_MAX;
	maxX = INT_MIN;
	for (int i = 0; i < N; i++) {
		int X;
		int Y;
		scanf("%d%d", &X, &Y);

		avgY += Y;

		if (X < minX)
			minX = X;
		if (X > maxX)
			maxX = X;

		pY[i] = Y;
	}

	// get shortest path 
	avgY = (long)((double)avgY / N);

	long minDist = 0;
	long centerY = 0;

	for (int i = 0; i < N; i++)
	{
		long dist = abs(pY[i] - avgY);

		if (i == 0 || dist < minDist)
		{
			minDist = dist;
			centerY = pY[i];
		}
	}

	long length = (long)abs(maxX - minX);

	for (int i = 0; i < N; i++)
		length += (long)abs(pY[i] - centerY);

	printf("%zu\n", length);
	return (0);
}
