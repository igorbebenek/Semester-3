function ddf = f_double_prime(f, x, h)
    ddf = (f(x + h) - 2*f(x) + f(x - h)) / (h^2);
end
