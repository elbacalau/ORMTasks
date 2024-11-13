import { Tablero } from "./tablero.interface";

export interface User {
  id:              number;
  nombre:          string;
  apellido:        string;
  segundoApellido?: string | null;
  email:           string;
  fechaRegistro:   Date;
  fechaNacimiento: Date;
  ciudad:          string;
  poblacion:       string;
  numeroTelefono:  string;
  tableros:        Tablero[];
}
