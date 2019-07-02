import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhoneNumberPipe implements PipeTransform {

  transform(value: string, ): string {
    let number = value.trim();
    let x = number.substring(0, 3);
    let y = number.substring(3, 6);
    let z = number.substring(6);

    return x + "/ " + y + "-" + z;
  }

}
