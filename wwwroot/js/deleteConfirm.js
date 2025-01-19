function confirmDelete(name, type, id, action) {
    Swal.fire({
        title: 'Bu işlem geri alınamaz!',
        text: `${type}: ${name} bilgisini silmek istediğinize emin misiniz.`,
        html: `<strong>${type}</strong>: <strong>${name}</strong> bilgisini silmek istediğinize emin misiniz.`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Evet, sil!',
        cancelButtonText: 'Hayır, vazgeç'
    }).then((result) => {
        if (result.isConfirmed) {
            const form = document.createElement('form');
            form.method = 'post';
            form.action = action;

            const input = document.createElement('input');
            input.type = 'hidden';
            input.name = 'id';
            input.value = id;

            form.appendChild(input);
            document.body.appendChild(form);
            form.submit();
        }
    });
}
