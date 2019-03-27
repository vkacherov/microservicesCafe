import { Component, Injectable, Inject } from '@angular/core';
import { OrderService } from '../order.service';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';

const STORAGE_KEY = 'mscafe_cashier_service_url';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})

@Injectable()
export class OrderFormComponent {
  private returnMsg;
  public orderPlacedMsg;
  private serviceUrl;

  constructor(
    private orderService: OrderService,
    @Inject(LOCAL_STORAGE) private storage: StorageService
  ) {}

  model = this.orderService.getOrder();

  submitted = false;

  ngOnInit() {
    this.model['serviceUrl'] = this.storage.get(STORAGE_KEY);
  }

  onSubmit() {
    // Save the service url in local storage
    console.log('Setting locaL storage', STORAGE_KEY, ': ', this.model['serviceUrl']);
    this.storage.set(STORAGE_KEY, this.model['serviceUrl']);

    console.log('LocaL storage', this.storage.get(STORAGE_KEY) || 'LocaL storage is empty');

    this.submitted = true;
    this.returnMsg = this.orderService.addOrder(this.model).subscribe();
    this.orderPlacedMsg = 'Thank you ' + this.model.name + '. Your order has been placed!';
    console.log(this.returnMsg);
  }
}
