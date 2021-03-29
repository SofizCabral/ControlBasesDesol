USE panelcontrolsql;

INSERT INTO tamanotablas
(
  instance
 ,base
 ,nombre
 ,filas
 ,resevadokb
 ,datoskb
 ,indicekb
 ,sinusokb
 ,fecha
 ,FechaActualizacion
)
VALUES
(
  '' -- instance - VARCHAR(45) NOT NULL
 ,'' -- base - VARCHAR(45) NOT NULL
 ,'' -- nombre - VARCHAR(45) NOT NULL
 ,0 -- filas - INT(11) NOT NULL
 ,0 -- resevadokb - INT(11) NOT NULL
 ,0 -- datoskb - INT(11)
 ,0 -- indicekb - INT(11)
 ,0 -- sinusokb - INT(11)
 ,NOW() -- fecha - DATETIME
 ,NOW() -- FechaActualizacion - DATETIME
);