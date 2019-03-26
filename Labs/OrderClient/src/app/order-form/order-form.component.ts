import { Component } from '@angular/core';
import { Order } from '../order';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})

export class OrderFormComponent {
  private returnMsg;
  constructor(private orderService: OrderService) {}

  model = this.orderService.getOrder();

  submitted = false;

  onSubmit() {
    this.submitted = true;
    this.returnMsg = this.orderService.addOrder(this.model).subscribe();
    console.log(this.returnMsg);
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }
}
