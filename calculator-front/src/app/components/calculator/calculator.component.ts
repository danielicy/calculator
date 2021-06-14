import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent {
  buttons = ['AC', '<', '%', '@', '7', '8', '9', 'x', '4', '5', '6', '-', '1', '2', '3', '+', '=', '0', '.', '/'];
  total = '';
  expression = '';

  handleClick(id: string): void{
    switch (id) {
      case 'AC':
        this.expression = '';
        break;
      case '<':
        this.expression = this.expression.slice(0, -1);
        break;
      case '%':
        alert("Not implemented yet");
        break;
      case '@':
        alert('Auto destruction mechanism activated you have 10 seconds to leave the room before it explodes');
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
   console.log(this.expression);
 }

 calculate(): void{
   alert(this.expression);
 }


}
