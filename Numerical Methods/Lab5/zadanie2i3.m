clc;
close all;
% Zad2
%Podpunkt 1
fx = linspace(-1, 1, 100);
wielomian = 1./(25*fx.^2 + 1);
xInterp = -1:0.001:1;
wynik = interp1(fx, wielomian, xInterp);

plot(wynik)

%% Podpunkt 2 macierz
x = linspace(-1, 1, 3)';
f = 1./(25*x.^2 + 1);
y = f;

V = vander(x);

a = pinv(V) * y;

disp('Współczynniki wielomianu:');
disp(a);
%% Podpunkt 3 horner
P = zeros(size(x));
    for i = length(a):-1 :1
        P = P .* x + a(i);
    end
%% Zad3
[T, Wx] = newton_wielomian([-2, 1, 2, 4], [3, 1, -3, 8], 3);



