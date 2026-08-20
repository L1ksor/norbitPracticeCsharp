
SELECT Id, TownFrom, TownTo, TimeOut, TimeIn
FROM Trip
WHERE TownFrom = N'Москва' 
  AND TimeOut >= '2026-09-01 00:00:00'
ORDER BY TimeOut ASC;


UPDATE Pass_in_trip
SET Place = N'01A'
WHERE Place = N'12A';


DELETE FROM Pass_in_trip
WHERE Place IS NULL OR Place = N'';


SELECT 
    p.Name AS PassengerName,
    COUNT(pt.Id) AS TotalTicketsBought
FROM Passenger p
JOIN Pass_in_trip pt ON p.Id = pt.PassengerId
GROUP BY p.Id, p.Name
HAVING COUNT(pt.Id) >= 1
ORDER BY TotalTicketsBought DESC;


SELECT pas.Name,
    pt.Place,
    t.TownFrom,
    t.TownTo,
    t.TimeOut,
    c.Name AS CompanyName,
    pl.Model AS PlaneModel
FROM Pass_in_trip pt
JOIN Passenger pas ON pt.PassengerId = pas.Id
JOIN Trip t ON pt.TripId = t.Id
JOIN Company c ON t.CompanyId = c.Id
JOIN Plane pl ON t.PlaneId = pl.Id;


SELECT p.Name, pt.Place
FROM Passenger p
LEFT JOIN Pass_in_trip pt ON p.Id = pt.PassengerId;

SELECT 
    pl.Model,
    pl.PassengerCapacity,
    t.TownFrom,
    t.TownTo,
    t.TimeOut
FROM Trip t
RIGHT JOIN Plane pl ON t.PlaneId = pl.Id;