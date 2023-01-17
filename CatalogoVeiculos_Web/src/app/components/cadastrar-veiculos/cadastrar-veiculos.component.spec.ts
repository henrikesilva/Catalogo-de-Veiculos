import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarVeiculosComponent } from './cadastrar-veiculos.component';

describe('CadastrarVeiculosComponent', () => {
  let component: CadastrarVeiculosComponent;
  let fixture: ComponentFixture<CadastrarVeiculosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastrarVeiculosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CadastrarVeiculosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
