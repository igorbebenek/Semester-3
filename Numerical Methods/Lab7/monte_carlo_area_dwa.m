function area = monte_carlo_area_dwa(x, y, y2, num_shots)
    x_min = min(x);
    x_max = max(x);
    y_min = min(min(y), min(y2));
    y_max = max(max(y), max(y2));
    hits = 0;

    plot(x, y, 'b', x, y2, 'b');
    hold on;
    
    for i = 1:num_shots
        x_rand = x_min + (x_max - x_min) * rand();
        y_rand = y_min + (y_max - y_min) * rand();
        y_top = interp1(x, y, x_rand, 'linear', 'extrap');
        y_bottom = interp1(x, y2, x_rand, 'linear', 'extrap');
 
        if y_rand <= y_top && y_rand >= y_bottom
            hits = hits + 1;
            plot(x_rand, y_rand, 'g.');  % zielony trafiony
        else
            plot(x_rand, y_rand, 'r.');  % pudlo
        end
    end
    
    hold off;
    area = (hits / num_shots) * (x_max - x_min) * (y_max - y_min); %pole
end
