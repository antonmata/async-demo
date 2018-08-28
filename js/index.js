async function run() {
  const sample1 = () =>
    new Promise((resolve, reject) => {
      resolve(1);
      // reject('Error!');
    });

  // sample1()
  //   .then(x => console.log(x))
  //   .catch(reason => console.warn(reason));

  try {
    const x = await sample1();
    console.log(x);
  } catch (error) {
    console.warn(error);
  }

  const sample2 = () => Promise.resolve(2);

  // sample2()
  //   .then(x => console.log(x))
  //   .catch(reason => console.warn(reason));

  const y = await sample2();
  console.log(y);

  console.log('hello');

  // fetch('http://localhost:5000/api/todo')
  //   .then(res => res.json())
  //   .then(json => console.log(json));

  const res1 = await fetch('http://localhost:5000/api/todo', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      name: 'Async Sample',
      completed: false,
    }),
  });
  const data1 = await res1.json();

  console.log(data1);

  const res2 = await fetch('http://localhost:5000/api/todo');
  const data2 = await res2.json();

  console.log(data2);
}

run().then();
