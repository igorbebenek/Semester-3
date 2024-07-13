clc;
close all;
clear;

A = [2 1; 3 3; 2 0; 1 0; 0 1];
B = [10; 24; 8; 0; 0];
Z = [-1; -1; -1; 1; 1];
F = [300, 200];

[w, ~] = size(A);

intersection_points = [];

for i = 1:w
    for j = i+1:w
        M = [A(i,:); A(j,:)];
        if rank(M) < 2
            continue;
        end
        Y = [B(i); B(j)];
        solution = M \ Y;
        if all(A * solution <= B + 1e-5 | Z >= 0) && all(A * solution >= B - 1e-5 | Z <= 0)
            intersection_points = [intersection_points, solution];
        end
    end
end

figure; hold on;
x_range = linspace(-10, 20, 400);
for i = 1:w
    y_range = (B(i) - A(i,1) * x_range) / A(i,2);
    plot(x_range, y_range, 'b');
end

K = convhull(intersection_points(1,:), intersection_points(2,:));
fill(intersection_points(1,K), intersection_points(2,K), 'yellow');

max_value = -inf;
max_point = [0; 0];
for i = 1:size(intersection_points, 2)
    point = intersection_points(:, i);
    value = F * point;
    if value > max_value
        max_value = value;
        max_point = point;
    end
end

plot(max_point(1), max_point(2), 'ro'); 

slope = -F(1) / F(2);
intercept = max_value / F(2);
y_func = slope * x_range + intercept;
plot(x_range, y_func, 'r', 'LineWidth', 2);

title(['Maksymalna wartość funkcji celu wynosi: ', num2str(max_value), ' dla x = ', num2str(max_point(1)), ', y = ', num2str(max_point(2))]);

xlim([0, 10]);
ylim([0, 10]);
xlabel('x');
ylabel('y');
hold off;
