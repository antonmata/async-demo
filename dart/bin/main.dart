import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;

import '../lib/todo_items.dart';

void main() async {
  var x = await sample1();
  print(x);
  await ajax();
}

Future<int> sample1() async {
  return 1;
}

Future<void> ajax() async {
  var uri = Uri.parse('http://localhost:5000/api/todo');

  final res1 = await http.get(uri);
  final data1 = TodoItems.fromJson(json.decode(res1.body));

  print(data1.items);
  print('\n');

  var newItem = TodoItem(name: 'Love from Dart');

  final res2 = await http.post(uri,
      headers: {
        'Content-Type': 'application/json',
      },
      body: JsonEncoder().convert(newItem.toJson()));
  final data2 = TodoItem.fromJson(json.decode(res2.body));

  print(data2);
}
