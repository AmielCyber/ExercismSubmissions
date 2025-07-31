class Node<TElement> {
  value: TElement;
  next: Node<TElement> | null = null;
  prev: Node<TElement> | null = null;

  constructor(value: TElement) {
    this.value = value;
  }
}

export class LinkedList<TElement> {
  #size = 0;
  #head: Node<TElement> | null = null;
  #tail: Node<TElement> | null = null;

  public push(element: TElement) {
    const newNode = new Node(element);
    if (this.#tail === null) {
      this.#head = newNode;
      this.#tail = newNode;
    } else {
      newNode.prev = this.#tail;
      this.#tail.next = newNode;
      this.#tail = newNode;
    }
    this.#size++;
  }

  public pop(): TElement {
    if (this.#tail === null) {
      throw new Error('Can not pop from an empty LinkedList.');
    }
    const node = this.#tail;
    this.#tail = node.prev;
    if (this.#tail !== null) {
      this.#tail.next = null;
    } else {
      this.#head = this.#tail;
    }
    this.#size--;
    return node.value;
  }

  public shift(): TElement {
    if (this.#head === null) {
      throw new Error('Can not shift from an empty LinkedList.');
    }
    const node = this.#head;
    this.#head = node.next;
    if (this.#head !== null) {
      this.#head.prev = null;
    } else {
      this.#tail = this.#head;
    }
    this.#size--;
    return node.value;
  }

  public unshift(element: TElement) {
    const newNode = new Node(element);
    if (this.#head === null) {
      this.#head = newNode;
      this.#tail = newNode;
    } else {
      newNode.next = this.#head;
      this.#head.prev = newNode;
      this.#head = newNode;
    }
    this.#size++;
  }

  public delete(element: TElement) {
    if (element !== null && element === this.#head?.value) {
      this.shift();
      return;
    }
    if (element !== null && element === this.#tail?.value) {
      this.pop();
      return;
    }
    if (this.#size <= 2) {
      return;
    }
    if (this.#head === null) {
      throw new Error('Can not delete from an empty LinkedList.');
    }
    let prev = this.#head;
    let node = this.#head.next;
    while (node !== null && node.value !== element) {
      prev = node;
      node = node.next;
    }
    if (node !== null) {
      prev.next = node.next;
      if (node.next !== null) {
        node.next.prev = prev;
      }
      this.#size--;
    }
  }

  public count(): number {
    return this.#size;
  }
}
