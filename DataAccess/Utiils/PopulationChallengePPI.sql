USE ChallengePPIDatabase;

-- Insertar en TipoActivo
INSERT INTO TipoActivos (Descripcion)
VALUES ('Accion'), ('Bono'), ('FCI');

-- Insertar en TipoEstados
INSERT INTO TipoEstados (Descripcion)
VALUES ('En proceso'), ('Ejecutada'), ('Cancelada');

INSERT INTO Activos (Ticker, Nombre, TipoActivoId, PrecioUnitario, Tipo)
VALUES 
    ('AAPL', 'Apple', 1, 177.97, 'Accion'),
    ('GOOGL', 'Alphabet Inc', 1, 138.21, 'Accion'),
    ('MSFT', 'Microsoft', 1, 329.04, 'Accion'),
    ('KO', 'Coca Cola', 1, 58.3, 'Accion'),
    ('WMT', 'Walmart', 1, 163.42, 'Accion'),
    ('AL30', 'BONOS ARGENTINA USD 2030 L.A', 2, 307.4, 'Bono'),
    ('GD30', 'Bonos Globales Argentina USD', 2, 336.1, 'Bono'),
    ('Delta.Pesos', 'Delta Pesos Clase A', 3, 0.0181, 'FCI'),
    ('Fima.Premium', 'Fima Premium Clase A', 3, 0.0317, 'FCI');
