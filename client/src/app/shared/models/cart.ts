import {nanoid} from 'nanoid';

export type CartType = {
  id: string;
  items: CartItem[];
}

export type CartItem = {
  productId: number;
  productName: string;
  price: number;
  quantity: number;
  pictureUrl: string;
  brand: string;
  type: string;
}
//nanoid() ile sepet oluşur oluşmaz benzersiz bir ID üretiyoruz.
export class Cart implements CartType {
  id = nanoid();
  items: CartItem[] = [];
}
//Cart class’ı oluşturduk. Bu class CartType içindeki bütün alanları içermesi gerektiğini garanti ediyor.