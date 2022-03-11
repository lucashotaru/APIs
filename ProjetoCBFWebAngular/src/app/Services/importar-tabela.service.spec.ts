import { TestBed } from '@angular/core/testing';

import { ImportarTabelaService } from './importar-tabela.service';

describe('ImportarTabelaService', () => {
  let service: ImportarTabelaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImportarTabelaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
