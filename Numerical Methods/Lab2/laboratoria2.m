%%
clc
clear all
close all 

u.okno = figure 
set(u.okno)
set(u.okno,'Name','zad2','NumberTitle','off')
u.edycja = uicontrol('Style','edit','Position',[100,200,200,50])
u.przycisk = uicontrol('Style','pushbutton','Position',[100,100,200,50],'String','OK','Callback',{@user_edit,u})
function user_edit(h, ~,u)
kolor=get(u.edycja,'String')

 switch kolor
     case 'red'
       set(u.okno,'Color','red') 
     case 'green'
        set(u.okno,'Color','green')
     case 'blue'
        set(u.okno,'Color','blue')
  end
end
