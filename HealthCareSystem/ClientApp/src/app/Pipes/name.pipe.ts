import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'name'
})
export class NamePipe implements PipeTransform {

  transform(value: string): string {

    var length = value.length;

    if (value[length - 1] === 'c' && value[length - 2] === 'i') {
      value = value.substring(0, length-2);
      value = value + "ić";
    }
    return value;
  }
}
