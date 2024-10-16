export const PhoneService = {
    getPhonesData() {
        return [
            {
                id: '1000',
                name: 'Bamboo Watch',
                phoneNumber: '500123321'
            },
            {
                id: '1001',
                name: 'Black Watch',
                phoneNumber: 'Product Description',
            },
            {
                id: '1002',
                name: 'Blue Band',
                phoneNumber: 'Product Description',
            },
            {
                id: '1003',
                name: 'Blue T-Shirt',
                phoneNumber: 'Product Description',
            },
            {
                id: '1004',
                name: 'Bracelet',
                phoneNumber: 'Product Description'
            },
            {
                id: '1005',
                name: 'Brown Purse',
                phoneNumber: 'Product Description'
            },
            {
                id: '1006',
                name: 'Chakra Bracelet',
                phoneNumber: 'Product Description'
            },
            {
                id: '1007',
                name: 'Galaxy Earrings',
                phoneNumber: 'Product Description'
            },
            {
                id: '1008',
                name: 'Game Controller',
                phoneNumber: 'Product Description'
            },
            {
                id: '1009',
                name: 'Gaming Set',
                phoneNumber: 'Product Description'
            },
            {
                id: '1010',
                name: 'Gold Phone Case',
                phoneNumber: 'Product Description'
            },
            {
                id: '1011',
                name: 'Green Earbuds',
                phoneNumber: 'Product Description'
            },
            {
                id: '1012',
                name: 'Green T-Shirt',
                phoneNumber: 'Product Description'
            },
            {
                id: '1013',
                name: 'Grey T-Shirt',
                phoneNumber: 'Product Description'
            },
            {
                id: '1014',
                name: 'Headphones',
                phoneNumber: 'Product Description'
            },
            {
                id: '1015',
                name: 'Light Green T-Shirt',
                phoneNumber: 'Product Description'
            },
            {
                id: '1016',
                name: 'Lime Band',
                phoneNumber: 'Product Description'
            },
            {
                id: '1017',
                name: 'Mini Speakers',
                phoneNumber: 'Product Description'
            },
            {
                id: '1018',
                name: 'Painted Phone Case',
                phoneNumber: 'Product Description'
            },
            {
                id: '1019',
                name: 'Pink Band',
                phoneNumber: 'Product Description'
            },
            {
                id: '1020',
                name: 'Pink Purse',
                phoneNumber: 'Product Description'
            },
            {
                id: '1021',
                name: 'Purple Band',
                phoneNumber: 'Product Description'
            },
            {
                id: '1022',
                name: 'Purple Gemstone Necklace',
                phoneNumber: 'Product Description'
            },
            {
                id: '1023',
                name: 'Purple T-Shirt',
                phoneNumber: 'Product Description'
            },
            {
                id: '1024',
                name: 'Shoes',
                phoneNumber: 'Product Description'
            },
            {
                id: '1025',
                name: 'Sneakers',
                phoneNumber: 'Product Description'
            },
            {
                id: '1026',
                name: 'Teal T-Shirt',
                phoneNumber: 'Product Description'
            },
            {
                id: '1027',
                name: 'Yellow Earbuds',
                phoneNumber: 'Product Description'
            },
            {
                id: '1028',
                name: 'Yoga Mat',
                phoneNumber: 'Product Description'
            },
            {
                id: '1029',
                name: 'Yoga Set',
                phoneNumber: 'Product Description'
            }
        ];
    },
    getPhones() {
        return Promise.resolve(this.getPhonesData());
    }
};

