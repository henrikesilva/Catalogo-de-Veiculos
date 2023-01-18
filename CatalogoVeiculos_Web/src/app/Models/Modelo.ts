import { Marca } from "./Marca";

export class Modelo{
    modeloId: number = 0;
    nomeModelo: string = '';
    statusModelo: boolean = true;
    marcaId: number = 0;

    marca: Marca = {
        marcaId: 0,
        nomeMarca: '',
        statusMarca: true
    };
    marcas?: Marca[];
}