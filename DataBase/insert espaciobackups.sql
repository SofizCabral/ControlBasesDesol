USE panelcontrolsql;

INSERT INTO espaciobakups
(
  Intance
 ,PathBUFull
 ,PathBUDif
 ,PathBULog
 ,PesoGbFull
 ,PesoGbDif
 ,PesoGbLog
 ,Disco
 ,EspacioTotalDisco
 ,EspacioLibreDisco
 ,FechaActualizacion
)
VALUES
(
  '' -- Intance - VARCHAR(45)
 ,'' -- PathBUFull - VARCHAR(45)
 ,'' -- PathBUDif - VARCHAR(45)
 ,'' -- PathBULog - VARCHAR(45)
 ,0 -- PesoGbFull - FLOAT
 ,0 -- PesoGbDif - FLOAT
 ,0 -- PesoGbLog - FLOAT
 ,'' -- Disco - VARCHAR(2)
 ,0 -- EspacioTotalDisco - FLOAT
 ,0 -- EspacioLibreDisco - FLOAT
 ,NOW() -- FechaActualizacion - DATETIME

);