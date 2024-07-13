clc;
clear all;

A1 = [2 1 1 0 0; 3 3 0 1 0; 2 0 0 0 1];
B1 = [10; 24; 8];
Z1 = [-1; -1; -1];
F1 = [300, 200, 0, 0, 0];
Wb1 = [3, 4, 5];
disp('Zestaw danych testowych 1:');
linear_programming_simplex(A1, B1, Z1, F1, Wb1);

% A2 = [1 2 1 0 0; 1 -2 0 1 0; 2 2 0 0 1];
% B2 = [8; 2; 10];
% Z2 = [-1; -1; -1];
% F2 = [2, 3, 0, 0, 0];
% Wb2 = [3, 4, 5];
% disp('Zestaw danych testowych 2:');
% linear_programming_simplex(A2, B2, Z2, F2, Wb2);



