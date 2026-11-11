# IA Básica Matematica - Manuel Dono Araújo

Este documento describe os cambios realizados ao proxecto.

A partir da escea dos tankes, crei un novo game object programado para funcionar como unha torreta.

Este inimigo foi creado a partir do script 'TanksNPCController', co novo script 'TowerNPC'. Este inclue as seguintes modificacións:

- Quitar a movilidade da torre en caso de non ter angulo
- Modificación da aparición da bala e angulo de torreta para afectar ao cañon
- Cambios de nomes de variables

O GameObject esta representado coma unha esfera de forma provisional. Orixinalmente estaba montado sobre unha torre feita a partir de rectangulos, pero isto afectaba aos calculos da bala, causando que o disparo sobrevoase o obxectivo. O diseño da torreta pasou a unha esfera simple, cando antes era un cilindro incrustado nun cubo para simular un cañón; pero ao non poder sincronizar a posición do cañón correctamente, decidín cambiar o obxecto por unha esfera con tal de cumplir cos requisitos do exercicio. 