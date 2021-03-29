USE panelcontrolsql;

INSERT INTO tamanobases
(
  instance
 ,base
 ,sizeMB
 ,freespacemb
 ,maxsize
 ,growth
 ,ispercentgrowth
 ,LogicName
 ,PhysicName
 ,Type
 ,fecha
 ,FechaActualizacion
)
VALUES
(
  '' -- instance - VARCHAR(45)
 ,'' -- base - VARCHAR(45)
 ,0 -- sizeMB - INT(11)
 ,0 -- freespacemb - INT(11)
 ,0 -- maxsize - INT(11)
 ,0 -- growth - INT(11)
 ,0 -- ispercentgrowth - TINYINT(1)
 ,'' -- LogicName - VARCHAR(45)
 ,'' -- PhysicName - VARCHAR(300)
 ,'' -- Type - VARCHAR(10)
 ,NOW() -- fecha - DATETIME
 ,NOW() -- FechaActualizacion - DATETIME
);