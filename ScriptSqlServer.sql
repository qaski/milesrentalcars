
--Instrucciones: ejecutar el presente script para crear el modelo er y poblarlo, 
-- para obtener la cadena de conexion ejecutar: SELECT 'Data Source=' + @@SERVERNAME + ';Initial Catalog=' + DB_NAME() + ';Integrated Security=SSPI;' el resultado colocarlo en el la variable: DefaultConnection del archivo appsettings ubicado en la capa de presentation
-- para 



-- Crear la tabla Localidad
CREATE TABLE Localidad (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

-- Crear la tabla CarActualLocation
CREATE TABLE CarActualLocation (
    Id INT PRIMARY KEY,
    Brand NVARCHAR(100) NOT NULL,
    IdActualLocation INT FOREIGN KEY REFERENCES Localidad(Id),
    Plate NVARCHAR(20) NOT NULL,
    [Date] DATETIME NOT NULL
);

-- Crear la tabla CarDevolutionLocation
CREATE TABLE CarDevolutionLocation (
    Id INT PRIMARY KEY,
    IdCar INT FOREIGN KEY REFERENCES CarActualLocation(Id),
    IdDevolutionLocation INT FOREIGN KEY REFERENCES Localidad(Id),
	[Date] DATETIME NOT NULL
);


-- Insertar 20 ciudades de Colombia en la tabla Localidad
INSERT INTO Localidad (Id, Nombre) VALUES
(1, 'Bogotá'),
(2, 'Medellín'),
(3, 'Cali'),
(4, 'Barranquilla'),
(5, 'Cartagena'),
(6, 'Cúcuta'),
(7, 'Bucaramanga'),
(8, 'Pereira'),
(9, 'Santa Marta'),
(10, 'Ibagué'),
(11, 'Pasto'),
(12, 'Manizales'),
(13, 'Neiva'),
(14, 'Soledad'),
(15, 'Villavicencio'),
(16, 'Armenia'),
(17, 'Soacha'),
(18, 'Valledupar'),
(19, 'Itagüí'),
(20, 'Montería');



-- Insertar datos en la tabla CarActualLocation
INSERT INTO CarActualLocation (Id, Brand, IdActualLocation, Plate, Date)
VALUES 
  (1, 'Chevrolet', 1, 'ABC123', GETDATE()),
  (2, 'Renault', 1, 'DEF456', GETDATE()),
  (3, 'BMW', 1, 'GHI789', GETDATE()),
  (4, 'Suzuki', 1, 'JKL012', GETDATE()),
  (5, 'Chevrolet', 1, 'MNO345', GETDATE()),
  (6, 'Renault', 1, 'PQR678', GETDATE()),
  (7, 'BMW', 1, 'STU901', GETDATE()),
  (8, 'Suzuki', 1, 'VWX234', GETDATE()),
  (9, 'Chevrolet', 1, 'YZA567', GETDATE()),
  (10, 'Renault', 1, 'BCD890', GETDATE()),
  (11, 'BMW', 1, 'EFG123', GETDATE()),
  (12, 'Suzuki', 1, 'HIJ456', GETDATE()),
  (13, 'Chevrolet', 1, 'KLM789', GETDATE()),
  (14, 'Renault', 1, 'NOP012', GETDATE()),
  (15, 'BMW', 1, 'QRS345', GETDATE()),
  (16, 'Suzuki', 1, 'TUV678', GETDATE()),
  (17, 'Chevrolet', 1, 'WXY901', GETDATE()),
  (18, 'Renault', 1, 'ZAB234', GETDATE()),
  (19, 'BMW', 1, 'CDE567', GETDATE()),
  (20, 'Suzuki', 1, 'FGH890', GETDATE())
;



