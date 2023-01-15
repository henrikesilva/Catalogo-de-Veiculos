import { Marca } from "./Marca";
import { Modelo } from "./Modelo";

export class Veiculos{
    VeiculoId: number = 0;
    Nome: string = '';
    Foto: string = '';
    Preco: number = 0.000;
    DataCriacao?: Date;
    DataAtualizacao?: Date;
    ModeloId: number = 0;
    MarcaId: number = 0;

    Modelo?: Modelo;
}