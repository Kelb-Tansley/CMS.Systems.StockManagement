import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { VehicleStockItem } from 'src/app/models/vehicleStockItem';
import { FormBuilder, FormGroup, FormControl } from "@angular/forms";

@Component({
  selector: 'app-stock-details',
  templateUrl: './stock-details.component.html',
  styleUrls: ['./stock-details.component.css']
})
export class StockDetailsComponent implements OnInit, OnDestroy {
  paramsSubscription: Subscription;
  // id: number;
  stockItem: VehicleStockItem;
  uploadForm: FormGroup;
  imageURL: string;
  toppings = new FormControl();
  toppingList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];

  constructor(private route: ActivatedRoute, private authorizeService: AuthorizeService, public fb: FormBuilder) {
    this.uploadForm = this.fb.group({
      avatar: [null],
      name: ['']
    });
  }

  ngOnInit() {
    this.stockItem = this.route.snapshot.params['id'];
    this.paramsSubscription = this.route.params.subscribe(
      (params: Params) => {
        this.stockItem = params['id'];
      }
    );
  }

  // Image Preview
  showPreview(event) {
    const file = (event.target as HTMLInputElement).files[0];
    this.uploadForm.patchValue({
      avatar: file
    });
    this.uploadForm.get('avatar').updateValueAndValidity();

    // File Preview
    const reader = new FileReader();
    reader.onload = () => {
      this.imageURL = reader.result as string;
    }
    reader.readAsDataURL(file);
  }

  // Submit Form
  submit() {
    console.log(this.uploadForm.value);
  }

  ngOnDestroy() {
    this.paramsSubscription.unsubscribe();
  }

  //async onSaveDetails() {
  //  let userName = await this.authorizeService.getUser().pipe(map(u => u && u.name));
  //  // this.stockItem.createdBy = userName.tostring();
  //}
}
