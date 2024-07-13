function metoda_davidona
   % f = @(x) (1/3)*x.^2 - (13/7)*x + 11;
    f = @(x) x.^4 - 12*x.^3 + x + 4;
   % a = -10;
  %  b = 10;
    a = -2;
    b = 2;
    tol = 1e-5;
    h = 0.001;

    tic;
    iter = 0;
    iteracje = [];
    wartosci_funkcji = [];

    while abs(f_prime(f, b, h)) > tol
        iter = iter + 1;

        fpa = f_prime(f, a, h);
        fpb = f_prime(f, b, h);

        Z = 3*(f(a) - f(b)) / (b - a) + fpa + fpb;
        Q = sqrt(Z^2 - fpa*fpb);

        xm = b - (fpb + Q - Z) / (fpb - fpa + 2*Q);

        iteracje(end+1) = iter;
        wartosci_funkcji(end+1) = f(xm);

        if f_prime(f, xm, h) > 0
            b = xm;
        else
            a = xm;
        end
    end

    czas = toc;

    fprintf('Znalezione minimum: %f\n', xm);
    fprintf('Liczba iteracji: %d\n', iter);
    fprintf('Czas: %f sekund\n', czas);

    figure;
    fplot(f, [-10 10]);
    hold on;
    plot(xm, f(xm), 'r*');
    title('Funkcja i znalezione minimum');
    xlabel('x');
    ylabel('f(x)');

    figure;
    plot(iteracje, wartosci_funkcji, '-o');
    title('Wartości funkcji w kolejnych iteracjach');
    xlabel('Iteracja');
    ylabel('f(x)');
end
