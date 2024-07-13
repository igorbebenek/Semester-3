function metoda_polowienia
   % f = @(x) (1/3)*x.^2 - (13/7)*x + 11;
     f = @(x) x.^4 - 12*x.^3 + x + 4;
    % przedzialy
  %  a = -10;
 %   b = 10;
    a = -2;
    b = 2;
    tol = 1e-5;
   
    tic;

    L = b - a;
    xm = (a + b) / 2;
    x1 = a + 0.25 * L;
    x2 = b - 0.25 * L;
    iter = 0;
    iteracje = [];
    wartosci_funkcji = [];

    while abs(f_prime(f, xm, 0.001)) >= tol && L > tol
        iter = iter + 1;
        fx1 = f(x1);
        fx2 = f(x2);
        fxm = f(xm);

        iteracje(end+1) = iter;
        wartosci_funkcji(end+1) = fxm;

        if fx1 < fxm
            b = xm;
            xm = x1;
        elseif fx2 < fxm
            a = xm;
            xm = x2;
        else
            a = x1;
            b = x2;
        end

        L = b - a;
        x1 = a + 0.25 * L;
        x2 = b - 0.25 * L;
    end

    czas = toc;

    % printy
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

    % Wykres 
    figure;
    plot(iteracje, wartosci_funkcji, '-o');
    title('Wartości funkcji w kolejnych iteracjach');
    xlabel('Iteracja');
    ylabel('f(x)');
end
