import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'calc-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent  {
@Input() id!: string;




}
