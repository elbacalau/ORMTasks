export interface TableroUserData {
  id:            number;
  titulo:        string;
  descripcion:   string;
  fechaCreacion: Date;
}

export interface Tablero {
  id:            number;
  titulo:        string;
  descripcion:   string;
  fechaCreacion: Date;
  userId:        number;
  propietario:   Propietario;
}

export interface Propietario {
  id:              number;
  nombre:          string;
  apellido:        string;
  segundoApellido: null;
  email:           string;
  fechaNacimiento: Date;
  ciudad:          string;
  poblacion:       string;
  numeroTelefono:  string;
}
