import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'password'
})
export class PasswordPipe implements PipeTransform {

  transform(value: string): string {

    var names = value.split(" ");

    return names[0].toLowerCase() + "123";
  }
}
