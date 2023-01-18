import { Marca } from "./Marca";
import { Modelo } from "./Modelo";
import { Usuario } from "./Usuario";

export class Veiculos{
    veiculoId: number = 0;
    nome: string = '';
    foto: string = '';
    preco: number = 0.000;
    dataCriacao?: Date;
    dataAtualizacao?: Date;
    statusVeiculo: boolean = true;
    modeloId: number = 0;
    marcaId: number = 0;
    usuarioId: number = 0;

    usuario: Usuario = {
        usuarioId: 0,
        nome: '',
        administrador: false,
        loginUsuario: '',
        statusUsuario: true,
        senha: ''
    };

    modelo: Modelo = {
        modeloId: 0,
        nomeModelo: '',
        marcaId: 0,
        statusModelo: true,
        marca: {
            marcaId: 0,
            nomeMarca: '',
            statusMarca: true
        }
    };
}