#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main()
{
	// game loop
	while (42) {
		char	enemy1[256]; // name of enemy 1
		char	enemy2[256]; // name of enemy 2
		int		dist1; // distance to enemy 1
		int		dist2; // distance to enemy 2

		scanf("%s", enemy1);
		scanf("%d", &dist1);
		scanf("%s", enemy2);
		scanf("%d", &dist2);

		if (dist1 < dist2)
			printf("%s\n", enemy1);
		else
			printf("%s\n", enemy2);
	}

	return (0);
}
