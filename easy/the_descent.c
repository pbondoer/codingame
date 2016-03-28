#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main()
{
	while (42) {
		int cur;
		int highId;
		int highH;

		highId = 0;
		highH = 0;
		for (int i = 0; i < 8; i++) {
			scanf("%d", &cur);
			if (cur > highH)
			{
				highH = cur;
				highId = i;
			}
		}

		printf("%d\n", highId);
	}

	return (0);
}
