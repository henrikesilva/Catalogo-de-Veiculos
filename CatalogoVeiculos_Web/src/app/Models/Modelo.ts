import { Marca } from "./Marca";

export class Modelo{
    ModeloId: number = 0;
    NomeModelo: string = '';
    MarcaId: number = 0;

    Marca?: Marca;
}