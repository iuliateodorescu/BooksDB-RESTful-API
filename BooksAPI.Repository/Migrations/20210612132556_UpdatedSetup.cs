using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAPI.Repository.Migrations
{
    public partial class UpdatedSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Description", "EditionYear", "ImageUrl", "Publisher", "Title" },
                values: new object[,]
                {
                    { 11, "Jean Rhys", "If Antoinette Cosway, a spirited Creole heiress, could have foreseen the terrible future that awaited her, she would not have married the young Englishman. Initially drawn to her beauty and sensuality, he becomes increasingly frustrated by his inability to reach into her soul. He forces Antoinette to conform to his rigid Victorian ideals, unaware that in taking away her identity he is destroying a part of himself as well as pushing her towards madness.", 2011, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/2419/9780241951552.jpg", "Penguin Books", "Wide Sargasso Sea" },
                    { 12, "Fyodor Dostoyevsky", "The murder of brutal landowner Fyodor Karamazov changes the lives of his sons irrevocably: Mitya, the sensualist, whose bitter rivalry with his father immediately places him under suspicion for parricide; Ivan, the intellectual, driven to breakdown; the spiritual Alyosha, who tries to heal the family's rifts; and the shadowy figure of their bastard half-brother, Smerdyakov. Dostoyevsky's dark masterwork evokes a world where the lines between innocence and corruption, good and evil, blur, and everyone's faith in humanity is tested.", 2003, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1404/9780140449242.jpg", "Penguin Books", "The Brothers Karamazov" },
                    { 13, "Jane Austen", "During an eventful season at Bath, young, naive Catherine Morland experiences the joys of fashionable society for the first time. She is delighted with her new acquaintances: flirtatious Isabella, who shares Catherine's love of Gothic romance and horror, and sophisticated Henry and Eleanor Tilney, who invite her to their father's mysterious house, Northanger Abbey. There, her imagination influenced by novels of sensation and intrigue, Catherine imagines terrible crimes committed by General Tilney. With its broad comedy and irrepressible heroine, this is the most youthful and and optimistic of Jane Austen's works.", 2012, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1413/9780141389424.jpg", "Penguin Books", "Northanger Abbey" },
                    { 14, "F. Scott Fitzgerald", "This Side of Paradise, F. Scott Fitzgerald's romantic and witty first novel, was written when the author was only twenty-three years old. This semiautobiographical story of the handsome, indulged, and idealistic Princeton student Amory Blaine received critical raves and catapulted Fitzgerald to instant fame. Now readers can enjoy the newly edited, authorized version of this early classic of the Jazz Age, based on Fitzgerald's original manuscript. In this definitive text, This Side of Paradise captures the rhythms and romance of Fitzgerald's youth and offers a poignant portrait of the Lost Generation.", 2000, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/4862/9780486289991.jpg", "Dover Publications", "This Side of Paradise" },
                    { 15, "Patrick Suskind", "In eighteenth-century France there lived a man who was one of the most gifted and abominable personages in an era that knew no lack of gifted and abominable personages. His name was Jean-Baptiste Grenouille, and if his name has been forgotten today, it is certainly not because Grenouille fell short of those more famous blackguards when it came to arrogance, misanthropy, immorality, or, more succinctly, wickedness, but because his gifts and his sole ambition were restricted to a domain that leaves no traces in history: to the fleeting realm of scent . . .", 2010, "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/1410/9780141041155.jpg", "Penguin Books", "Perfume: The Story of a Murderer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 15);
        }
    }
}
