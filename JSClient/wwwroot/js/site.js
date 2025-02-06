async function fetchProduct() {
    const productId = document.getElementById('productId').value;

    const response = await fetch(`https://localhost:7001/products/${productId}`);
    if (response.status === 404) {
        console.error('Failed to fetch product');
        document.getElementById('productDetails').innerText = 'Failed to fetch product! Product not found!';
    }
    else {
        const product = await response.json();
        document.getElementById('productDetails').innerText = `Name: ${product.name}, Price: $${product.price}`;
    }
 }