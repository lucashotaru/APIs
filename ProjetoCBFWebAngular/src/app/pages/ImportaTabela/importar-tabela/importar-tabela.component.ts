import { Component, OnInit } from '@angular/core';
import { ImportarTabelaService } from 'src/app/Services/importar-tabela.service';

@Component({
  selector: 'app-importar-tabela',
  templateUrl: './importar-tabela.component.html',
  styleUrls: ['./importar-tabela.component.css']
})
export class ImportarTabelaComponent implements OnInit {

  shortLink: string = "";
  loading: boolean = false; // Flag variable
  file: any = null; // Variable to store file

  // Inject service
  constructor(private fileUploadService: ImportarTabelaService) { }

  ngOnInit(): void {
  }

  // On file Select
  onChange(event: any) {
      this.file = event.target.files[0];
  }

  // OnClick of button Upload
  onUpload() {
      this.loading = !this.loading;
      console.log(this.file);
      this.fileUploadService.upload(this.file).subscribe(
          (event: any) => {
              if (typeof (event) === 'object') {

                  // Short link via api response
                  this.shortLink = event.link;

                  this.loading = false; // Flag variable
              }
          }
      );
  }
}
