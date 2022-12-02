using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryOrganizer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(maxLength: 200, nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Titles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Carissa", "Broadbent" },
                    { 2, "Stephanie", "Garber" },
                    { 3, "Jodi", "Meadows" },
                    { 4, "Margaret", "Rogerson" },
                    { 5, "Rebecca", "Ross" },
                    { 6, "Melissa", "Wright" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "AuthorId", "BookTitle", "Description", "IsRead", "Rating", "Review" },
                values: new object[,]
                {
                    { 1, 1, "Daughter of No Worlds", "Her life for freedom. Her blood for love. Her soul for vengeance. Ripped from a forgotten homeland as a child, Tisaanah learned how to survive with nothing but a sharp wit and a touch of magic. But the night she tries to buy her freedom, she barely escapes with her life. Desperate to save the best friend she left behind, Tisaanah journeys to the Orders, the most powerful organization of magic Wielders in the world. But to join their ranks, she must complete an apprenticeship with Maxantarius Farlione, a handsome and reclusive fire wielder who despises the Orders. The Orders’ intentions are cryptic, and Tisaanah must prove herself under the threat of looming war. Even more dangerous are her growing feelings for Maxantarius. The bloody past he wants to forget may be the key to her future… or the downfall of them both. But Tisaanah will stop at nothing to save those she abandoned. Even if it means gambling in the Orders’ deadly games. Even if it means sacrificing her heart. Even if it means wielding death itself.", true, 5, null },
                    { 2, 6, "Seven Ways to Kill a King", "Myrina of Stormskeep was dead. Everyone knew the princess had been slain when the murderous lords of the Storm Queen’s Realm stole her mother’s throne to crown themselves kings. But far away in Smithsport hides a dark-haired girl known as Bean. Each night when the last flame is snuffed inside the Blackwater Inn and her need for secrecy devoured by the darkness, Princess Myrina plots the death of seven kings. One will seem an accident. Two a coincidence. By three, they will know. But vengeance rarely goes according to plan. The worst of the kings holds her sister--rightful queen and heir to the realm--captive. If Lettie isn’t freed before she comes into her magic, the kings will hold her power as well. Myrina can let nothing stop her, even the boy from her past who ignites feelings she long ago buried. With the help of her loyal bloodsworn Cass, the shadow princess will have her revenge. Vowed to enact retribution and rescue her sister with no more than her wits and a sword--and the last of her queensguard--this YA fantasy is perfect for fans of Shielded and The Princess Will Save You.", true, 4, "I love tropey books like this. Melissa is so good at writing books that just give me exactly what I want in these kinds of books." },
                    { 3, 2, "The Ballad of Never After", "Not every love is meant to be. After Jacks, the Prince of Hearts, betrays her, Evangeline Fox swears she'll never trust him again. Now that she’s discovered her own magic, Evangeline believes she can use it to restore the chance at happily ever after that Jacks stole away. But when a new terrifying curse is revealed, Evangeline finds herself entering into a tenuous partnership with the Prince of Hearts again. Only this time, the rules have changed. Jacks isn’t the only force Evangeline needs to be wary of. In fact, he might be the only one she can trust, despite her desire to despise him. Instead of a love spell wreaking havoc on Evangeline’s life, a murderous spell has been cast. To break it, Evangeline and Jacks will have to do battle with old friends, new foes, and a magic that plays with heads and hearts. Evangeline has always trusted her heart, but this time she’s not sure she can...", true, 4, "Man this one HURT" },
                    { 4, 6, "Between Ink and Shadows", "She’ll win back her freedom, even if she has to steal it. Nimona Weston has a debt to pay. Her father’s dealings with the dark society known as the Trust cost Nim her freedom. There’s one way out of the contract on her life and that’s to bide her time and pay the tithes. But when the Trust assigns Nim to a task in the king’s own castle, her freedom is not the only thing she’ll risk. Warrick Spenser has a secret. As king’s seneschal, he should be the last soul in Inara to risk association with dark magic, but long-hidden ties to the Trust are harder to shed than simply cutting the threads. When the Trust sends a thief to his rooms, Warrick thinks he’s finally found a way to be rid of them for good. But Nimona Weston is hiding secrets of her own. Magical contracts, blood-debt accountants, and a deadly game. A dark and twisty fantasy that pits magic against kings.", true, 4, "Damsel in distress? Check!! Broody hot forbidden romance? Check!!" },
                    { 5, 5, "A River Enchanted", "House of Earth and Blood meets The Witch's Heart in Rebecca Ross’s brilliant first adult fantasy, set on the magical isle of Cadence where two childhood enemies must team up to discover why girls are going missing from their clan. Jack Tamerlaine hasn’t set foot on Cadence in ten long years, content to study music at the mainland university. But when young girls start disappearing from the isle, Jack is summoned home to help find them. Enchantments run deep on Cadence: gossip is carried by the wind; plaid shawls can be as strong as armor; and the smallest cut of a knife can instill fathomless fear. The capricious spirits that rule the isle by fire, water, earth, and wind find mirth in the lives of the humans who call the land home. Adaira, heiress of the east and Jack’s childhood enemy, knows the spirits only answer to a bard’s music, and she hopes Jack can draw them forth by song, enticing them to return the missing girls. As Jack and Adaira reluctantly work together, they find they make better allies than rivals as their partnership turns into something more. But with each passing song, it becomes apparent the trouble with the spirits is far more sinister than they first expected, and an older, darker secret about Cadence lurks beneath the surface, threatening to undo them all. With unforgettable characters, a fast-paced plot, and compelling world building, A River Enchanted is a stirring story of duty, love, and the power of true partnership, and marks Rebecca Ross’s brilliant entry on the adult fantasy stage.", true, 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Titles_AuthorId",
                table: "Titles",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
