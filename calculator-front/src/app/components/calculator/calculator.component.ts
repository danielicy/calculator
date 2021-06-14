import { HttpHeaders } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ApiHttpService } from 'src/app/core/services/api/api-http.service';

@Component({
  selector: 'calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent implements OnDestroy {
  buttons = ['AC', '<', '%', '@', '7', '8', '9', 'x', '4', '5', '6', '-', '1', '2', '3', '+', '=', '0', '.', '/'];
  total = '';
  expression = '';
  subscription: any;

  constructor(
    // Angular Modules
    private api: ApiHttpService
  ) { }
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  handleClick(id: string): void{
    switch (id) {
      case 'AC':
        this.expression = '';
        break;
      case '<':
        this.expression = this.expression.slice(0, -1);
        break;
      case '%':
        alert('Not implemented yet');
        break;
      case '@':
        alert('There is a theory which states that if ever anyone discovers exactly what the Universe is for and why it is here, it will instantly disappear and be replaced by something even more bizarre and inexplicable');
        break;
      case '=':
        this.calculate();
        break;
        default:
          this.expression = this.expression.concat(id);

    }
  }

 click(id: string): void{
   this.handleClick(id);
 }

 calculate(): void{

  this.api.get('calculator?expression=' + this.expression
  .replace(/\+/g, '%2B') .replace(/x/g, '*'))
   .subscribe(result => {
    this.expression = this.expression.concat('=', result as any);

   });
 }


}
