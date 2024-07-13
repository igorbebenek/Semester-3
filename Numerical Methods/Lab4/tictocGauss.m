n = 5000;
e = 0.01;
A = rand(n, n);
E = eye(n);
A = A + n * E;
x = ones(n, 1);
b = A * x;

tic;
x_gc = eliminacjaGauss(A, b);
czas_gc = toc;

disp(['Czas wykonania eliminacji Gaussa-Crouta dla rozmiaru: ', num2str(czas_gc), ' sekund']);
