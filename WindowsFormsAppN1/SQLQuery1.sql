use Авіярейси 
go
CREATE PROCEDURE UpdateПассажиры

AS	
	select Фамилия_пасажира from Пассажиры
	
	Where Фамилия_пасажира = 'Цинтар'
	 begin
    update Пассажиры set Фамилия_пасажира = 'Панків' where Фамилия_пасажира= Пассажиры.Фамилия_пасажира
  end
GO