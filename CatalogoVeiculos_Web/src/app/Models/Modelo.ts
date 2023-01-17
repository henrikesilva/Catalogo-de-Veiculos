import { Marca } from "./Marca";

export class Modelo{
    modeloId: number = 0;
    nomeModelo: string = '';
    marcaId: number = 0;

    marca: Marca = {
        marcaId: 0,
        nomeMarca: ''
    };
    marcas?: Marca[];
}